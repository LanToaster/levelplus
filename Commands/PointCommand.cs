using Terraria.ModLoader;

namespace levelplus.Commands {
    class PointCommand : ModCommand {
        public override string Command => "points";

        public override string Description => "Adds points";
        public override CommandType Type => CommandType.Chat;

        public override string Usage => "/points <amount>";

        public override void Action(CommandCaller caller, string input, string[] args) {
            levelplusModPlayer player = caller.Player.GetModPlayer<levelplusModPlayer>();

            player.AddPoints(int.Parse(args[0]));
        }
    }
    
    class XPCommand : ModCommand {
        public override string Command => "AddXp";

        public override string Description => "Gives Experience";
        public override CommandType Type => CommandType.Chat;

        public override string Usage => "/AddXp <amount>";

        public override void Action(CommandCaller caller, string input, string[] args) {
            levelplusModPlayer player = caller.Player.GetModPlayer<levelplusModPlayer>();
            player.AddXp(ulong.Parse(args[0]));

        }

    }
}

