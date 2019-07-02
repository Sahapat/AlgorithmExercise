using System;
using System.Text;

using static System.Console;

namespace Exercise
{
    /* 
        The game MMORPG have to send the small package.
        We have a player status that have to pack in one int variable

        Create the program that Pack and Unpack the package

        #Note status

        1 <= exp <= 1000000
        1 <= Level <= 60
        gender have a char data 'f' and 'm'
        1 <= CharacterType <= 25
     */
     
    public class PackageProblem
    {
        internal struct PlayerData
        {
            internal int experience;
            internal byte level;
            internal char gender;
            internal byte characterType;
        }
        public static void Run()
        {
            PlayerData playerData = new PlayerData();
            for (int i = 0; i < 4;)
            {
                Clear();
                string inputString = string.Empty;
                WriteLine("Input the player status");
                WriteLine("1.Experience: {0}\n2.Level: {1}\n3.Gender: {2}\n4.CharacterType: {3}", (playerData.experience == 0) ? " " : playerData.experience.ToString(), (playerData.level == 0) ? " " : playerData.level.ToString(), (playerData.gender == '\x0000') ? " " : playerData.gender.ToString(), (playerData.characterType == 0) ? " " : playerData.characterType.ToString());
                Write("Input ({0}): ", i + 1);
                inputString = ReadLine();

                try
                {
                    if (i == 0)
                    {
                        playerData.experience = int.Parse(inputString);
                        if (!(playerData.experience <= 0 && playerData.experience > 1000000))
                        {
                            i++;
                        }
                        else
                        {
                            playerData.experience = 0;
                        }
                        continue;
                    }
                    else if (i == 1)
                    {
                        playerData.level = byte.Parse(inputString);
                        if (!(playerData.experience <= 0 && playerData.experience > 60))
                        {
                            i++;
                        }
                        else
                        {
                            playerData.level = 0;
                        }
                        continue;
                    }
                    else if (i == 2)
                    {
                        playerData.gender = char.Parse(inputString);
                        if (playerData.gender == 'f' || playerData.gender == 'm')
                        {
                            i++;
                        }
                        else
                        {
                            playerData.gender = '\x0000';
                        }
                        continue;
                    }
                    else if (i == 3)
                    {
                        playerData.characterType = byte.Parse(inputString);
                        if (!(playerData.experience <= 0 && playerData.experience > 25))
                        {
                            i++;
                        }
                        else
                        {
                            playerData.characterType = 0;
                        }
                        continue;
                    }
                }
                catch (FormatException)
                {
                    continue;
                }
            }
            int package = Packaging(playerData);
            PlayerData getData = DePackage(package);

            Clear();

            WriteLine(ToBinaryString(package));
            WriteLine("1.Experience: {0}\n2.Level: {1}\n3.Gender: {2}\n4.CharacterType: {3}", getData.experience, getData.level, getData.gender, getData.characterType);

        }
        static int Packaging(PlayerData data)
        {
            int exp = data.experience;
            int level = data.level;
            int gender = (data.gender == 'f') ? (int)0 : (int)1;
            int characterType = data.characterType;

            return (int)((exp << 12) | (level << 6) | (characterType << 1) | gender);
        }
        static PlayerData DePackage(int package)
        {
            int expKey = 1048575 << 12;
            int levelKey = 63 << 6;
            int characterTypeKey = 31 << 1;
            int genderKey = 1;

            int exp = (package & expKey) >> 12;
            int level = (package & levelKey) >> 6;
            int characterType = (package & characterTypeKey) >> 1;
            int gender = (package & (genderKey));

            return new PlayerData() { experience = exp, level = (byte)level, gender = (gender == 0) ? 'f' : 'm', characterType = (byte)characterType };
        }
        static string ToBinaryString(int package)
        {
            StringBuilder stgBuilder = new StringBuilder();
            stgBuilder.Append(Convert.ToString(package, 2));
            while (stgBuilder.Length < 32)
            {
                stgBuilder.Insert(0, "0");
            }
            return stgBuilder.ToString();
        }
    }
}