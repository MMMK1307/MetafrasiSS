using MetafrasiSS.Infra.DataModels.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MetafrasiSS.Infra.Persistence.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<DataUserModel>
{
	public void Configure(EntityTypeBuilder<DataUserModel> builder)
	{
		builder.Property(x => x.UserName)
			.HasMaxLength(300);

		builder.Property(x => x.Email)
			.HasMaxLength(300);

		builder.Property(x => x.Name)
			.HasMaxLength(300);

		builder.Property(x => x.PasswordHash)
			.HasMaxLength(100);

		builder.Property(x => x.SecurityStamp)
			.HasMaxLength(40);
		
		builder.Property(x => x.ConcurrencyStamp)
			.HasMaxLength(40);
		
		builder.Property(x => x.PhoneNumber)
			.HasMaxLength(40);

		builder.HasIndex(x => x.UserName)
			.IsUnique();

		builder.HasIndex(x => x.Email)
			.IsUnique();
	}
}