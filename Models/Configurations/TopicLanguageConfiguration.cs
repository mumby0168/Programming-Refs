using System.Net.Sockets;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Programming_Reference_Website.Models.Configurations
{
    public class TopicLanguageConfiguration : IEntityTypeConfiguration<TopicLanguage>
    {
        public void Configure(EntityTypeBuilder<TopicLanguage> builder)
        {
            builder.HasKey(tl => new { tl.TopicId, tl.LanguageId});

            builder
            .HasOne(tl => tl.Language)
            .WithMany(tl => tl.TopicLanguages)
            .HasForeignKey(tl => tl.LanguageId);

            builder
            .HasOne(tl => tl.Topic)
            .WithMany(tl => tl.TopicLanguages)
            .HasForeignKey(tl => tl.TopicId);                              
        }
    }
}