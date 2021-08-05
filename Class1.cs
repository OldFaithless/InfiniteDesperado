using System;
using BepInEx;
using BepInEx.Configuration;
using RoR2;

namespace Bandito
{
    [BepInDependency("com.bepis.r2api")]
    //Change these
    [BepInPlugin("com.OldFaithless.PersistentDesperado", "Persistent Desperado", "1.1.1")]
    public class BanditInfiniteScaling : BaseUnityPlugin
    {

        public static ConfigEntry<double> StackValue { get; set; }
        public void Awake()
        {

            StackValue = Config.Bind<double>(
                "Bandit",
                "StackBonus",
                0.02,
                "The percentage damage increase per stack of Desperado, expressed as a decimal (0.02f is equivalent to 2% per stack)."

            );

            On.EntityStates.Bandit2.Weapon.FireSidearmSkullRevolver.ModifyBullet += (orig, self, bulletAttack) =>
            {
                float baseDamage = bulletAttack.damage;
                orig(self, bulletAttack);
                float stackBonus = (float)((bulletAttack.damage - baseDamage) * (StackValue.Value / 0.1));
                bulletAttack.damage = baseDamage + stackBonus;
            };

            On.RoR2.PreGameController.StartRun += (orig, self) =>
            {
                BanditName1 = "";
                BanditName2 = "";
                BanditName3 = "";
                BanditName4 = "";
                BanditName5 = "";
                BanditName6 = "";
                BanditName7 = "";
                BanditName8 = "";
                BanditCount1 = 0;
                BanditCount2 = 0;
                BanditCount3 = 0;
                BanditCount4 = 0;
                BanditCount5 = 0;
                BanditCount6 = 0;
                BanditCount7 = 0;
                BanditCount8 = 0;
                orig(self);
            };

            On.RoR2.CharacterBody.RecalculateStats += (orig, self) =>
            {
                bool flag = self.isPlayerControlled && self.teamComponent.teamIndex == TeamIndex.Player;
                bool flag2 = flag;
                if (flag2)
                {
                    String myBanditName = self.GetUserName();
                    int banditLoc11 = FindName(myBanditName);
                    //Logger.LogMessage("banditloc is " + banditLoc11);
                    //if (banditLoc11 == -1)
                    //{
                    //    BanditNames.Add(myName);
                    //    BanditCounts.Add(self.GetBuffCount(RoR2Content.Buffs.BanditSkull));
                    //    banditLoc11 = BanditNames.IndexOf(myName);
                    //    Logger.LogMessage("Added " + myName);
                    //}
                    int numCoins = GetCount(banditLoc11);
                    bool needCoins = self.GetBuffCount(RoR2Content.Buffs.BanditSkull) < numCoins;
                    if (needCoins)
                    {
                        int buffCount = self.GetBuffCount(RoR2Content.Buffs.BanditSkull);
                        for (int i = 0; i < numCoins - buffCount; i++)
                        {
                            self.AddBuff(RoR2Content.Buffs.BanditSkull);
                            //Logger.LogMessage(" aka " + myBanditName + "filled coin -- banditloc " + banditLoc11);
                        }
                    }

                    bool coinsUp = self.GetBuffCount(RoR2Content.Buffs.BanditSkull) > numCoins;
                    if (coinsUp)
                    {
                        //Logger.LogMessage(" aka " + myBanditName + "get coin -- banditloc " + banditLoc11);
                        if (banditLoc11 == 1)
                        {
                            BanditCount1 = self.GetBuffCount(RoR2Content.Buffs.BanditSkull);
                        }
                        if (banditLoc11 == 2)
                        {
                            BanditCount2 = self.GetBuffCount(RoR2Content.Buffs.BanditSkull);
                        }
                        if (banditLoc11 == 3)
                        {
                            BanditCount3 = self.GetBuffCount(RoR2Content.Buffs.BanditSkull);
                        }
                        if (banditLoc11 == 4)
                        {
                            BanditCount4 = self.GetBuffCount(RoR2Content.Buffs.BanditSkull);
                        }
                        if (banditLoc11 == 5)
                        {
                            BanditCount5 = self.GetBuffCount(RoR2Content.Buffs.BanditSkull);
                        }
                        if (banditLoc11 == 6)
                        {
                            BanditCount6 = self.GetBuffCount(RoR2Content.Buffs.BanditSkull);
                        }
                        if (banditLoc11 == 7)
                        {
                            BanditCount7 = self.GetBuffCount(RoR2Content.Buffs.BanditSkull);
                        }
                        if (banditLoc11 == 8)
                        {
                            BanditCount8 = self.GetBuffCount(RoR2Content.Buffs.BanditSkull);
                        }
                    }
                }
                orig(self);
            };
        }

        public int FindName(string bName)
        {
            if (bName == BanditName1 || BanditName1 == "")
            {
                BanditName1 = bName;
                return 1;
            }
            if (bName == BanditName2 || BanditName2 == "")
            {
                BanditName2 = bName;
                return 2;
            }
            if (bName == BanditName3 || BanditName3 == "")
            {
                BanditName3 = bName;
                return 3;
            }
            if (bName == BanditName4 || BanditName4 == "")
            {
                BanditName4 = bName;
                return 4;
            }
            if (bName == BanditName5 || BanditName5 == "")
            {
                BanditName5 = bName;
                return 5;
            }
            if (bName == BanditName6 || BanditName6 == "")
            {
                BanditName6 = bName;
                return 6;
            }
            if (bName == BanditName7 || BanditName7 == "")
            {
                BanditName7 = bName;
                return 7;
            }
            if (bName == BanditName8 || BanditName8 == "")
            {
                BanditName8 = bName;
                return 8;
            }

            return -1;
        }

        public int GetCount(int num)
        {
            if (num == 1)
            {
                return BanditCount1;
            }
            if (num == 2)
            {
                return BanditCount2;
            }
            if (num == 3)
            {
                return BanditCount3;
            }
            if (num == 4)
            {
                return BanditCount4;
            }
            if (num == 5)
            {
                return BanditCount5;
            }
            if (num == 6)
            {
                return BanditCount6;
            }
            if (num == 7)
            {
                return BanditCount7;
            }
            if (num == 8)
            {
                return BanditCount8;
            }
            return -1;
        }

        public string BanditName1;
        public string BanditName2;
        public string BanditName3;
        public string BanditName4;
        public string BanditName5;
        public string BanditName6;
        public string BanditName7;
        public string BanditName8;
        public int BanditCount1;
        public int BanditCount2;
        public int BanditCount3;
        public int BanditCount4;
        public int BanditCount5;
        public int BanditCount6;
        public int BanditCount7;
        public int BanditCount8;
    }
}
