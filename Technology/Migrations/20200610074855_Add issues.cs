using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Technology.WebPortal.Migrations
{
    public partial class Addissues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    SurName = table.Column<string>(nullable: true),
                    MidName = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Designation = table.Column<string>(nullable: true),
                    Department = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "IssueCategories",
                columns: table => new
                {
                    IssueCategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueCategories", x => x.IssueCategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Issues",
                columns: table => new
                {
                    IssueID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    EmployerID = table.Column<int>(nullable: false),
                    IssueCategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issues", x => x.IssueID);
                    table.ForeignKey(
                        name: "FK_Issues_Employees_EmployerID",
                        column: x => x.EmployerID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Issues_IssueCategories_IssueCategoryID",
                        column: x => x.IssueCategoryID,
                        principalTable: "IssueCategories",
                        principalColumn: "IssueCategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    EmployerID = table.Column<int>(nullable: false),
                    IssueID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentID);
                    table.ForeignKey(
                        name: "FK_Comments_Employees_EmployerID",
                        column: x => x.EmployerID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Issues_IssueID",
                        column: x => x.IssueID,
                        principalTable: "Issues",
                        principalColumn: "IssueID");
                });

            migrationBuilder.CreateTable(
                name: "Attachments",
                columns: table => new
                {
                    AttachmentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(nullable: true),
                    Content = table.Column<byte[]>(nullable: true),
                    CommentID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachments", x => x.AttachmentID);
                    table.ForeignKey(
                        name: "FK_Attachments_Comments_CommentID",
                        column: x => x.CommentID,
                        principalTable: "Comments",
                        principalColumn: "CommentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Address", "Department", "Designation", "MidName", "Name", "Phone", "SurName" },
                values: new object[,]
                {
                    { 1, "Москва", "Отдел разработки", "Разработчик", "Игоревич", "Иван", "001-1102", "Петров" },
                    { 2, "Москва", "Отдел аналитики", "Аналитик", "Ивановна", "Марина", "001-1122", "Ковалева" },
                    { 3, "Москва", "Отдел сопровождения", "Сопровождение", "Семенович", "Анатолий", "001-1134", "Павлов" },
                    { 4, "Москва", "Группа тестирования", "Тестировщик", "Алексеевич", "Дмитрий", "001-1187", "Загребин" },
                    { 5, "Москва", "Бухгалтерия", "Бухгалтер", "Владимировна", "Дарья", "001-1191", "Васильева" },
                    { 6, "Москва", "ИТ поддержка", "Специалист ИТ", "Петрович", "Василий", "001-1223", "Кулешов" },
                    { 7, "Москва", "Фин поддержка", "Финансовый консультант", "Викторович", "Игорь", "001-1401", "Семенов" }
                });

            migrationBuilder.InsertData(
                table: "IssueCategories",
                columns: new[] { "IssueCategoryID", "Description", "Type" },
                values: new object[,]
                {
                    { 1, "IT Service Desk", 1 },
                    { 2, "Fin Support", 2 }
                });

            migrationBuilder.InsertData(
                table: "Issues",
                columns: new[] { "IssueID", "Description", "EmployerID", "IssueCategoryID", "Number" },
                values: new object[] { 1, "Сетевая проблема", 2, 1, "IT-0001" });

            migrationBuilder.InsertData(
                table: "Issues",
                columns: new[] { "IssueID", "Description", "EmployerID", "IssueCategoryID", "Number" },
                values: new object[] { 2, "Проблема с компьютером", 5, 1, "IT-0002" });

            migrationBuilder.InsertData(
                table: "Issues",
                columns: new[] { "IssueID", "Description", "EmployerID", "IssueCategoryID", "Number" },
                values: new object[] { 3, "Оформление справки", 4, 2, "FIN-0001" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentID", "Date", "EmployerID", "IssueID", "Text" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, "Проблема с сетью, не работает интернет. Скриншот приложен" },
                    { 4, new DateTime(2020, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 1, "Проверяю ваши сетевые настройки" },
                    { 2, new DateTime(2020, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 2, "Проблема с компьютером, не могу включить. Скриншот приложен" },
                    { 5, new DateTime(2020, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 2, "Задача в работе. Смогу через час посмотреть компьютер." },
                    { 3, new DateTime(2020, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 3, "Помогите оформить справку 2-НДФЛ" },
                    { 6, new DateTime(2020, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 3, "Задача взята в работу. Справка будет в понедельник." }
                });

            migrationBuilder.InsertData(
                table: "Attachments",
                columns: new[] { "AttachmentID", "CommentID", "Content", "FileName" },
                values: new object[] { 1, 1, new byte[] { 0 }, "скриншот.png" });

            migrationBuilder.InsertData(
                table: "Attachments",
                columns: new[] { "AttachmentID", "CommentID", "Content", "FileName" },
                values: new object[] { 2, 2, new byte[] { 0 }, "описание ошибки.png" });

            migrationBuilder.InsertData(
                table: "Attachments",
                columns: new[] { "AttachmentID", "CommentID", "Content", "FileName" },
                values: new object[] { 3, 3, new byte[] { 0 }, "проблема.png" });

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_CommentID",
                table: "Attachments",
                column: "CommentID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_EmployerID",
                table: "Comments",
                column: "EmployerID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_IssueID",
                table: "Comments",
                column: "IssueID");

            migrationBuilder.CreateIndex(
                name: "IX_Issues_EmployerID",
                table: "Issues",
                column: "EmployerID");

            migrationBuilder.CreateIndex(
                name: "IX_Issues_IssueCategoryID",
                table: "Issues",
                column: "IssueCategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attachments");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Issues");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "IssueCategories");
        }
    }
}
