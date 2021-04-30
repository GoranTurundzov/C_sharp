using System.Collections.Generic;
using System.Linq;

namespace Models
{
    public class League
    {
        public string Name { get; set; }
        public string Season { get; set; }
        //Liverpool 0+3
        //Chelsea 0
        //Arsenal 0
        public List<Team> Teams { get; set; } = new List<Team>();
        //Liverpool vs Chelsea 2 - 1
        //Liverpool vs Arsenal 0 - 0
        public List<Match> Matches { get; set; } = new List<Match>();

        public League(string name, string season)
        {
            Name = name;
            Season = season;
        }

        public void CreateMatches()
        {
            int matches = (Teams.Count) * (Teams.Count - 1);
            if (Teams.Count % 2 != 0)
            {
                Teams.Add(new Team());
               
            }
            while (Matches.Count < matches)
            { 
                for (int i = 0; i < Teams.Count / 2; i++)
                {
                    if(Teams[i].Name == null || Teams[Teams.Count - (i + 1)].Name == null)
                    {
                        continue;
                    }else
                    {
                        Matches.Add(new Match(Teams[i], Teams[Teams.Count - (i + 1)]));
                    }

                }
                Team temp = Teams[0];
                Teams.RemoveAt(0);
                Teams.Add(temp);


            }

            //foreach (var team1 in Teams)
            //{
            //    foreach (var team2 in Teams)
            //    {
            //        if (team1.Name == team2.Name)
            //        {
            //            continue;
            //        }

            //        Match match = new Match(team1, team2);
            //        Matches.Add(match);
            //    }
            //}
        }

        public void SimulateAllMatches()
        {
            foreach (var match in Matches)
            {
                match.SimulateMatch();

                if (match.Team1Goals > match.Team2Goals)
                {
                    //winner first
                    Team winner = Teams.First(x => x.Name == match.Team1.Name);
                    Team looser = Teams.First(x => x.Name == match.Team2.Name);
                    winner.Points += 3;
                    winner.NumberOfWins++;
                    looser.NumberOfLoses++;
                    winner.NumberOfScoredGoals += match.Team1Goals;
                    winner.NumberOfConcededGoals += match.Team2Goals;

                    looser.NumberOfScoredGoals += match.Team2Goals;
                    looser.NumberOfConcededGoals += match.Team1Goals;
                } 
                else if (match.Team1Goals < match.Team2Goals)
                {
                    //winner second
                    Team winner = Teams.First(x => x.Name == match.Team2.Name);
                    Team looser = Teams.First(x => x.Name == match.Team1.Name);
                    winner.Points += 3;
                    winner.NumberOfWins++;
                    looser.NumberOfLoses++;
                    
                    winner.NumberOfScoredGoals += match.Team2Goals;
                    winner.NumberOfConcededGoals += match.Team1Goals;

                    looser.NumberOfScoredGoals += match.Team1Goals;
                    looser.NumberOfConcededGoals += match.Team2Goals;
                }
                else
                {
                    //draw
                    Team team1 = Teams.First(x => x.Name == match.Team1.Name);
                    Team team2 = Teams.First(x => x.Name == match.Team2.Name);
                    team1.Points += 1;
                    team2.Points += 1;
                    team1.NumberOfDraws++;
                    team2.NumberOfDraws++;
                    
                    team1.NumberOfScoredGoals += match.Team1Goals;
                    team1.NumberOfConcededGoals += match.Team2Goals;

                    team2.NumberOfScoredGoals += match.Team2Goals;
                    team2.NumberOfConcededGoals += match.Team1Goals;
                }
            }
        }

        public string GetInfo()
        {
            return $"{Name} {Season}\n";
        }

        public string GetMatches()
        {
            string matches = "Matches:\n ";
            int fullMatches = (Teams.Count) * (Teams.Count - 1);
            int matchUps = Matches.Count;
            int playsPerWeek = Teams.Count / 2;
            if(fullMatches != matchUps)
            {
                playsPerWeek--;
            }
            int counter = -1;
            int kolo = 0;
            foreach (Match match in Matches)
            {
                counter++;
             
                if (counter % playsPerWeek == 0) 
                {
                    kolo++;
                    matches += $"Kolo {kolo}: \n";
                }
                
                //matches += $"{match.Team1.Name,20} | {match.Team2.Name,20} | {match.Team1Goals,5} | {match.Team2Goals,5}\n";
                //matches += string.Format("{0,20} | {1,20} | {2,5} | {3,5} |\n", match.Team1.Name, match.Team2.Name, match.Team1Goals, match.Team2Goals);
                string team1Score = match.Status == MatchStatus.Finished ? match.Team1Goals.ToString() : "-";
                string team2Score = match.Status == MatchStatus.Finished ? match.Team2Goals.ToString() : "-";
                matches += $"{match.Team1.Name,20} vs {match.Team2.Name,-20} | {team1Score,3} : {team2Score,-3}\n";
            }

            return matches;
        }

        public string GetTable()
        {
            List<Team> orderTable = Teams.OrderByDescending(x => x.Points).ToList();

            string table = "Table:\n";
            table += $"{"No.",4} {"Name",-20} | {"GP",-5} | {"Wins",-5} | {"Draws",-5} | {"Loses",-5} | {"SG",5}:{"CG",-5} | Points\n";
            //table += string.Join("\n", orderTable.Select(x => $"{x.Name,20} | {x.Points}"));
            int count = 1;
            for (int i = 0; i < orderTable.Count; i++)
            {
                if (orderTable[i].Name == null) continue;
                table += $"{count,3}. {orderTable[i].Name,-20} | {orderTable[i].GamePlayed,-5} | {orderTable[i].NumberOfWins,-5} | {orderTable[i].NumberOfDraws,-5} | {orderTable[i].NumberOfLoses,-5} | {orderTable[i].NumberOfScoredGoals,5}:{orderTable[i].NumberOfConcededGoals,-5} | {orderTable[i].Points}\n";
                count++;
            }

            return table;
        }
    }
}
