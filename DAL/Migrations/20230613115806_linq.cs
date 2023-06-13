using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class linq : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
          @"CREATE PROCEDURE GetPatientsByName
              @Name NVARCHAR(100)
              AS
              BEGIN
                  SELECT * FROM Patients WHERE Name LIKE '%' + @Name + '%'
              END");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
