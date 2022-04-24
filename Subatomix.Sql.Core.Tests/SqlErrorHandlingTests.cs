namespace Subatomix.Sql.Core;

[TestFixture]
public class SqlErrorHandlingTests
{
    private const string Eol = @"
";

    [Test]
    public void Apply()
    {
        var wrapped = SqlErrorHandling.Apply(new[] {
            "a"
        ,
            "b"          + Eol +
            "--# NOWRAP" + Eol +
            "c"
        });

        wrapped.Should().StartWith(
            "DECLARE @__sql__ nvarchar(max);"  + Eol +
            "BEGIN TRY"                        + Eol +
            ""                                 + Eol +
            "    SET @__sql__ = N'a';"         + Eol +
            "    EXEC sp_executesql @__sql__;" + Eol +
            ""                                 + Eol +
            "    SET @__sql__ = N'b"           + Eol +
            "--# NOWRAP"                       + Eol +
            "c';"                              + Eol +
            "b"                                + Eol +
            "--# NOWRAP"                       + Eol +
            "c"                                + Eol +
            ""                                 + Eol +
            "END TRY"                          + Eol
       );
    }
}
