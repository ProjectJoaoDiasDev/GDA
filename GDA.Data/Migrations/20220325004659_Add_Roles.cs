using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GDA.Data.Migrations
{
    public partial class Add_Roles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"insert into AspNetRoles values ('5B4AD7A5-2EA0-4B51-AA82-A86343B6BC20', 'SysAdmin', 'SysAdmin', null), ('F8B5A07E-D113-4AE5-8698-2ACEEC1F4531', 'StudentManager', 'StudentManager', null), ('87B74E0A-5B51-492D-B42F-CB3863E62934', 'Student', 'Student', null);");
            migrationBuilder.Sql("insert AspNetUsers (Id, UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount) VALUES (N'AC227B87-1620-42D9-860C-E9773381B46D', N'Aline', N'Aline', N'joaodiasworking@gmail.com', N'joaodiasworking@gmail.com', 1, N'ANgdvzXOTMMzLiNMfSctV801fzuTXVBlPPPX9VokVB/Ad8OoEk4sSUPkpcA3ROVaDw==', N'GLYT2WREALAQEOIAT7KCELYGFW6HSR2S', N'CDADC14F-F902-4BA7-B4F6-1E07C5055712', NULL, 0, 0, NULL, 0, 0);");
            migrationBuilder.Sql("insert INTO AspNetUserRoles values ('AC227B87-1620-42D9-860C-E9773381B46D', 'F8B5A07E-D113-4AE5-8698-2ACEEC1F4531'); ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
