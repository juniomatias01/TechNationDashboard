using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using TechNationDashboard.Data;

namespace TechNationDashboard.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TechNationDashboard.Entities.NotaFiscal", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<DateTime>("DataCobranca")
                    .HasColumnType("datetime2");

                b.Property<DateTime>("DataEmissao")
                    .HasColumnType("datetime2");

                b.Property<DateTime?>("DataPagamento")
                    .HasColumnType("datetime2");

                b.Property<string>("DocumentoBoletoBancario")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("DocumentoNotaFiscal")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("NomePagador")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("NumeroIdentificacao")
                    .HasColumnType("nvarchar(max)");

                b.Property<int>("Status")
                    .HasColumnType("int");

                b.Property<decimal>("Valor")
                    .HasColumnType("decimal(18,2)");

                b.HasKey("Id");

                b.ToTable("NotasFiscais");
            });
        }
    }
}
