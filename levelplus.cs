using Terraria.ModLoader;
using System.IO;
using Terraria;
using Terraria.ID;

namespace levelplus {

    internal enum PacketType {
        XP,
        Level
    }

    public class levelplus : Mod {
        public const string modID = "levelplus";
        private byte playernumber;

        public levelplus() { Instance = this; }

        public static levelplus Instance { get; set; }

        public override void HandlePacket(BinaryReader reader, int whoAmI) {
            byte msgType = reader.ReadByte();
            switch ((PacketType)msgType) {
                case PacketType.XP: //xp gain
                    if (Main.netMode == NetmodeID.MultiplayerClient)
                        Main.LocalPlayer.GetModPlayer<levelplusModPlayer>().AddXp(reader.ReadUInt64());
                    break;
                case PacketType.Level: //Set PlayerLevel
                    if (Main.netMode != NetmodeID.SinglePlayer)
                        playernumber = reader.ReadByte();
                        levelplusModPlayer TempPlayer = Main.player[playernumber].GetModPlayer<levelplusModPlayer>();
                        TempPlayer.level = (ushort)reader.ReadInt32();
                    break;
                default:
                    Logger.WarnFormat("levelplus: Unknown message type {0}", msgType);
                    break;
            }
        }
    }
}
