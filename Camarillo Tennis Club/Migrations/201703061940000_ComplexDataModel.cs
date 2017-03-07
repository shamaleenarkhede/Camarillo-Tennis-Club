namespace Camarillo_Tennis_Club.Models
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ComplexDataModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Matches",
                c => new
                    {
                        MatchID = c.Int(nullable: false, identity: true),
                        Location = c.String(),
                        MatchDate = c.DateTime(nullable: false),
                        Player1ID = c.Int(nullable: false),
                        Player2ID = c.Int(nullable: false),
                        PlayerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MatchID);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        PlayerID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 25),
                        LastName = c.String(maxLength: 25),
                        BDate = c.DateTime(nullable: false),
                        Players_PlayerID = c.Int(),
                        Matches_MatchID = c.Int(),
                        Score_ID = c.Int(),
                    })
                .PrimaryKey(t => t.PlayerID)
                .ForeignKey("dbo.Players", t => t.Players_PlayerID)
                .ForeignKey("dbo.Matches", t => t.Matches_MatchID)
                .ForeignKey("dbo.Score", t => t.Score_ID)
                .Index(t => t.Players_PlayerID)
                .Index(t => t.Matches_MatchID)
                .Index(t => t.Score_ID);
            
            CreateTable(
                "dbo.Score",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MatchID = c.Int(nullable: false),
                        PlayerID = c.Int(nullable: false),
                        Set1Score = c.Int(nullable: false),
                        Set2Score = c.Int(nullable: false),
                        Set3Score = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Matches", t => t.MatchID, cascadeDelete: true)
                .Index(t => t.MatchID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Players", "Score_ID", "dbo.Score");
            DropForeignKey("dbo.Score", "MatchID", "dbo.Matches");
            DropForeignKey("dbo.Players", "Matches_MatchID", "dbo.Matches");
            DropForeignKey("dbo.Players", "Players_PlayerID", "dbo.Players");
            DropIndex("dbo.Score", new[] { "MatchID" });
            DropIndex("dbo.Players", new[] { "Score_ID" });
            DropIndex("dbo.Players", new[] { "Matches_MatchID" });
            DropIndex("dbo.Players", new[] { "Players_PlayerID" });
            DropTable("dbo.Score");
            DropTable("dbo.Players");
            DropTable("dbo.Matches");
        }
    }
}
