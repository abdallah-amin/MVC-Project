
namespace Demo.DAL.Context.Configurations;
internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.Property(e => e.Name)
            .HasColumnType("VarChar")
            .HasMaxLength(30)
            .IsRequired(true);

        builder.Property(e => e.Email)
            .HasColumnType("VarChar")
            .HasMaxLength(30)
            .IsRequired(false);

        builder.Property(e => e.PhoneNumber)
            .HasColumnType("VarChar")
            .HasMaxLength(11)
            .IsRequired(false);

        builder.Property(e => e.Salary)
            .HasColumnType("decimal(10,2)")
            .IsRequired(true);

        builder.Property(e => e.Gender)
            .HasConversion(x => x.ToString(),
            s => Enum.Parse<Gender>(s));

    }
}
