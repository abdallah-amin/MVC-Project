namespace Demo.DAL.Context.Configurations;
internal class DepartmentConfigurations : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.Property(d => d.Id)
            .UseIdentityColumn(10, 10);

        builder.Property(d => d.Name)
            .IsRequired(true)
            .HasMaxLength(50)
            .HasColumnType("VarChar");

        builder.Property(d => d.Description)
            .IsRequired(false)
            .HasMaxLength(250)
            .HasColumnType("VarChar");

        builder.Property(d => d.Code)
            .IsRequired(true)
            .HasMaxLength(50)
            .HasColumnType("VarChar");

        builder.Property(d => d.CreatedOn)
            .HasDefaultValueSql("GETDATE()");
    }
}
