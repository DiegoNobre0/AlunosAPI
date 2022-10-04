using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _AlunosAPI.Migrations
{
    public partial class Tabela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into Alunos(Nome,Email,Idade,CPF)" +
            "Values('Maria da Penha','mariapenha@yahoo.com',23,'333.222.333.22')");

            migrationBuilder.Sql("Insert into Alunos(Nome,Email,Idade,CPF)" +
            "Values('Manuel Bueno','manuelbueno@yahoo.com',22,'444.222.111.69')");

            migrationBuilder.Sql("Insert into Alunos(Nome,Email,Idade,CPF)" +
            "Values('Diego Nobre','diegonobre@yahoo.com',24,'999.888.444.22')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Alunos");
        }
    }
}
