using Bogus;
using Microsoft.EntityFrameworkCore.Migrations;
using razorweb.Models;

#nullable disable

namespace razorweb.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //SQL Server
            //migrationBuilder.CreateTable(
            //    name: "Articles",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Title = table.Column<string>(type: "nvarchar(100)", maxLength: 255, nullable: false),
            //        CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        Content = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Articles", x => x.Id);
            //    });

            //PostgreSQL
            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "serial", nullable: false),  // Sử dụng 'serial' thay vì 'int' để tự động tăng
                    Title = table.Column<string>(type: "varchar(255)", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                });

            Randomizer.Seed = new Random(8675309);
            var fakerArticles = new Faker<Article>();
            fakerArticles.RuleFor(a => a.Title, f => f.Lorem.Sentence(5, 5)); //Tối thiểu 5 từ, thêm bớt 5 từ
            //fakerArticles.RuleFor(a => a.CreateAt, f => f.Date.Between(new DateTime(2020, 1, 1), DateTime.Now)); //SQL Server
            fakerArticles.RuleFor(a => a.CreateAt, f => f.Date.Between(new DateTime(2020, 1, 1).ToUniversalTime(), DateTime.UtcNow)); //PostgreSQL
            fakerArticles.RuleFor(a => a.Content, f => f.Lorem.Paragraphs(1, 4));
            for (int i = 0; i < 150; i++)
            {
                Article article = fakerArticles.Generate();
                migrationBuilder.InsertData(
                    table: "Articles",
                    columns: new[] { "Content", "CreateAt", "Title" },
                    values: new object[] { 
                        article.Content,
                        article.CreateAt,
                        article.Title
                    }
                );
            }


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");
        }
    }
}
