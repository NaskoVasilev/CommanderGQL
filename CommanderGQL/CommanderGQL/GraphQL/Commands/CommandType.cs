using CommanderGQL.Data;
using CommanderGQL.Models;

namespace CommanderGQL.GraphQL.Commands
{
    public class CommandType : ObjectType<Command>
    {
        protected override void Configure(IObjectTypeDescriptor<Command> descriptor)
        {
            descriptor.Description("Represents any executable command");

            descriptor
                .Field(c => c.Platform)
                .ResolveWith<Resolvers>(r => r.GetPlatform(default!, default!))
                .UseDbContext<AppDbContext>()
                .Description("This is the platorm to which the command belongs!");
        }

        private class Resolvers
        {
            public Platform? GetPlatform([Parent] Command command, [ScopedService] AppDbContext context)
                => context.Platforms.FirstOrDefault(p => p.Id == command.PlatformId);
        }
    }
}
