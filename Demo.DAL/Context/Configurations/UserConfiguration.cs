namespace Demo.DAL.Context.Configurations;
internal class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.Property(u => u.FirstName)
            .HasColumnType("VarChar")
            .HasMaxLength(250);

        builder.Property(u => u.LastName)
            .HasColumnType("VarChar")
            .HasMaxLength(250);

    }

}
