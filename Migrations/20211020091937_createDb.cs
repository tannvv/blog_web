using System;
using Bogus;
using Microsoft.EntityFrameworkCore.Migrations;

namespace blog_web.Migrations
{
    public partial class createDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "articles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_articles", x => x.ID);
                });
                Randomizer.Seed = new Random(8675309);
                var fakeArticle = new Faker<Article>();
                fakeArticle.RuleFor(a => a.Title, f => f.Lorem.Sentence(5,5) );
                fakeArticle.RuleFor(a => a.Created, f => f.Date.Between(new DateTime(2021,1,1),new DateTime(2022,1,1)) );
                fakeArticle.RuleFor(a => a.Content, f => f.Lorem.Paragraphs(1,4) );
                for (int i = 0; i < 100; i++)
                {
                    Article article = fakeArticle.Generate();
                    migrationBuilder.InsertData(
                    table: "articles",
                    columns: new[] { "Title", "Created", "Content" },
                    values: new Object[]{
                        article.Title,
                        article.Created,
                        article.Content
                    }
                );
                }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "articles");
        }
    }
}
