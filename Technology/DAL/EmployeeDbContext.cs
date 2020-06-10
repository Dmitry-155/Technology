using Microsoft.EntityFrameworkCore;
using System;
using Technology.WebPortal.Models;

namespace Technology.WebPortal.DAL
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<IssueCategory> IssueCategories { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Issue> Issues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // сотрудники
            modelBuilder.Entity<Employee>().HasData(
                new Employee() { EmployeeId = 1, Name = "Иван", SurName = "Петров", MidName = "Игоревич", Department = "Отдел разработки", Phone = "001-1102", Designation = "Разработчик", Address = "Москва" },
                new Employee() { EmployeeId = 2, Name = "Марина", SurName = "Ковалева", MidName = "Ивановна", Department = "Отдел аналитики", Phone = "001-1122", Designation = "Аналитик", Address = "Москва" },
                new Employee() { EmployeeId = 3, Name = "Анатолий", SurName = "Павлов", MidName = "Семенович", Department = "Отдел сопровождения", Phone = "001-1134", Designation = "Сопровождение", Address = "Москва" },
                new Employee() { EmployeeId = 4, Name = "Дмитрий", SurName = "Загребин", MidName = "Алексеевич", Department = "Группа тестирования", Phone = "001-1187", Designation = "Тестировщик", Address = "Москва" },
                new Employee() { EmployeeId = 5, Name = "Дарья", SurName = "Васильева", MidName = "Владимировна", Department = "Бухгалтерия", Phone = "001-1191", Designation = "Бухгалтер", Address = "Москва" },
                new Employee() { EmployeeId = 6, Name = "Василий", SurName = "Кулешов", MidName = "Петрович", Department = "ИТ поддержка", Phone = "001-1223", Designation = "Специалист ИТ", Address = "Москва" },
                new Employee() { EmployeeId = 7, Name = "Игорь", SurName = "Семенов", MidName = "Викторович", Department = "Фин поддержка", Phone = "001-1401", Designation = "Финансовый консультант", Address = "Москва" });

            // категории обращений
            modelBuilder.Entity<IssueCategory>().HasData(
                new IssueCategory() { IssueCategoryID = 1, Type = 1, Description = "IT Service Desk" },
                new IssueCategory() { IssueCategoryID = 2, Type = 2, Description = "Fin Support" });

            // обращения
            modelBuilder.Entity<Issue>()
                .HasMany(e => e.Comments)
                .WithOne(e => e.Issue)
                .OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<Employee>()
            //    .HasMany()
            //    .WithOne(m => m.EmployeeId)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Issue>()
            //            .HasRequired(m => m.GuestTeam)
            //            .WithMany(t => t.AwayMatches)
            //            .HasForeignKey(m => m.GuestTeamId)
            //            .WillCascadeOnDelete(false);

            modelBuilder.Entity<Issue>().HasData(
                new Issue()
                {
                    IssueID = 1,
                    Number = "IT-0001",
                    Description = "Сетевая проблема",
                    AuthorID = 2,
                    ExecutorID = 6,
                    IssueCategoryID = 1,
                },
                new Issue()
                {
                    IssueID = 2,
                    Number = "IT-0002",
                    Description = "Проблема с компьютером",
                    AuthorID = 5,
                    ExecutorID = 6,
                    IssueCategoryID = 1,
                },
                new Issue()
                {
                    IssueID = 3,
                    Number = "FIN-0001",
                    Description = "Оформление справки",
                    AuthorID = 4,
                    ExecutorID = 7,
                    IssueCategoryID = 2,
                });

            // комментарии
            var comment1 = new Comment()
            {
                CommentID = 1,
                Date = DateTime.Parse("2020-06-08"),
                Text = "Проблема с сетью, не работает интернет. Скриншот приложен",
                EmployerID = 2,
                IssueID = 1,
            };
            var comment2 = new Comment()
            {
                CommentID = 2,
                Date = DateTime.Parse("2020-06-09"),
                Text = "Проблема с компьютером, не могу включить. Скриншот приложен",
                EmployerID = 5,
                IssueID = 2,
            };
            var comment3 = new Comment()
            {
                CommentID = 3,
                Date = DateTime.Parse("2020-06-06"),
                Text = "Помогите оформить справку 2-НДФЛ",
                EmployerID = 4,
                IssueID = 3,
            };
            var comment4 = new Comment()
            {
                CommentID = 4,
                Date = DateTime.Parse("2020-06-09"),
                Text = "Проверяю ваши сетевые настройки",
                EmployerID = 6,
                IssueID = 1,
            };
            var comment5 = new Comment()
            {
                CommentID = 5,
                Date = DateTime.Parse("2020-06-10"),
                Text = "Задача в работе. Смогу через час посмотреть компьютер.",
                EmployerID = 6,
                IssueID = 2,
            };
            var comment6 = new Comment()
            {
                CommentID = 6,
                Date = DateTime.Parse("2020-06-05"),
                Text = "Задача взята в работу. Справка будет в понедельник.",
                EmployerID = 7,
                IssueID = 3,
            };
            modelBuilder.Entity<Comment>().HasData(comment1, comment2, comment3, comment4, comment5, comment6);

            // вложения
            var attach1 = new Attachment() { AttachmentID = 1, FileName = "скриншот.png", Content = new byte[] { 0x00 }, CommentID = 1 };
            var attach2 = new Attachment() { AttachmentID = 2, FileName = "описание ошибки.png", Content = new byte[] { 0x00 }, CommentID = 2 };
            var attach3 = new Attachment() { AttachmentID = 3, FileName = "проблема.png", Content = new byte[] { 0x00 }, CommentID = 3 };
            modelBuilder.Entity<Attachment>().HasData(attach1, attach2, attach3);
        }
    }
}
