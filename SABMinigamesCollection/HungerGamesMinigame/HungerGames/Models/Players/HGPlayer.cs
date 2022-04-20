using StarArisingBot.Minigames.HungerGames;
using System;
using System.Collections.Generic;
using System.Linq;

public class HGPlayer
{
    public string Name { get; set; }
    public int ID { get; set; }

    public int TotalKills { get; set; }

    public List<HGPlayer> ViewedPlayers = new List<HGPlayer>();
    public List<HGFriend> Friends = new List<HGFriend>();
    public HGInventory Inventory = new HGInventory();

    public HGPlayer LastPlayerSeen { get; set; }

    public HGBaseMessagePack[] DefautMessages =
    {
        new DefautMessagePack(),

        new AttackMessagePack(),
        new SuicideMessagePack(),
        new InteractionsMessagePack(),
        new FindObjectsMesagePack()
    };

    public int Age { get; set; }

    public int CurrentHealth { get; set; }
    public int MaxHealth { get; set; }

    public int CurrentSanity { get; set; }
    public int MaxSanity { get; set; }

    public int CurrentHappiness { get; set; }
    public int MaxHappiness { get; set; }

    public int Force { get; set; }
    public int ExtraForce { get; set; }

    public int ChanceToNormalAction { get; set; }
    public int ChanceToAttack { get; set; }
    public int ChanceToFindingItem { get; set; }
    public int ChanceToMakeFriend { get; set; }
    public int ChanceToSuicide { get; set; }
    public int ChanceToAccident { get; set; }

    public bool HaveFriends
    {
        get
        {
            if (Friends.Count > 0)
            {
                return true;
            }

            return false;
        }
    }
    private readonly Random Random = new Random();

    public HGPlayer Randomizer()
    {
        string[] names =
        {
            "Miguel", "Davi", "Gabriel", "Arthur", "Lucas", "Matheus", "Pedro", "Guilherme", "Gustavo", "Rafael", "Felipe", "Bernardo", "Enzo", "Nicolas", "Jo�o", "Cau�", "Vitor", "Eduardo", "Daniel", "Henrique", "Murilo", "Vinicius", "Samuel", "Pietro", "Leonardo", "Caio", "Heitor", "Lorenzo", "Isaac", "Lucca", "Thiago", "Theo", "Bryan", "Carlos", "Luiz", "Breno", "Emanuel", "Ryan", "Yuri", "Benjamin", "Erick", "Fernando", "Joaquim", "Andr�", "Tom�s", "Francisco", "Rodrigo", "Igor", "Antonio", "Ian", "Juan", "Diogo", "Ot�vio", "Nathan", "Calebe", "Danilo", "Luan", "Kaique", "Alexandre", "Iago", "Ricardo", "Raul", "Marcelo", "Cau�", "Ben�cio", "Augusto", "Pedro", "Luiz", "Giovanni", "Renato", "Diego", "Renan", "Anthony", "Thales", "Henry",  "Marcos", "Kevin", "Levi", "Enrico", "Hugo", "Alex", "Arthur", "Ester", "Jo�o", "Kayky", "Luiz", "Nicolas", "Renato", "Teodoro", "Benedito", "Cl�udio", "Jos�", "Edgar", "Milton", "Kl�ber", "Escobar", "Ivo", "Jonas", "Tadeu", "Manoel", "Sandro", "Vicente", "L�cio",
            "Emanuelly", "Isadora", "Ana", "Melissa", "Esther", "Lav�nia", "Mait�", "Maria", "Sarah", "Elisa", "Liz", "Yasmin", "Isabelly", "Al�cia", "Clara", "Isis", "Rebeca", "Rafaela", "Marina", "Helena", "Agatha", "Gabriela", "Catarina", "Let�cia", "Mirella", "Nicole", "Luna", "Vit�ria", "Ol�via", "Maria", "Beatriz", "Allana", "Valentina", "Milena", "Alice", "Laura", "Manuela", "Valentina", "Sophia", "Isabella", "Helo�sa", "Luiza", "J�lia", "Lorena", "L�via", "Cec�lia", "Elo�", "Giovanna", "Mariana", "Emilly", "Ayla", "Maya", "Bianca", "Clarice", "Aurora", "Larissa", "Mariah", "Pietra", "La�s", "Stella", "Eduarda", "Carolina", "Gabrielly", "Rayssa", "Paula", "Eliana", "Cl�udia", "Amanda", "Em�lia", "Edna", "Marcia", "Ver�nica", "Paloma", "Catarina", "Liana", "Talita", "Samanta", "Priscila", "Ol�via", "Neusa", "M�nica", "Julia", "Kelly", "Marcela", "Ivete", "Fabiane", "Esther", "Suzana", "Tatiana", "Elza", "Roberta", "Wanda", "Teresa", "Elaine", "Sandra", "Jessica", "F�tima", "Ivone", "Nina"
        };

        Name = names[Random.Next(0, names.Length)];
        TotalKills = 0;
        Age = Random.Next(18, 32);

        //=======================================//
        MaxHealth = 50;
        CurrentHealth = Random.Next(35, MaxHealth);

        MaxHappiness = 70;
        CurrentHappiness = Random.Next(50, MaxHappiness);

        MaxSanity = 100;
        CurrentSanity = Random.Next(50, MaxSanity);

        //=======================================//

        Force = Random.Next(10, 20);
        ExtraForce = 0;

        ChanceToFindingItem = Random.Next(10, 70);
        ChanceToNormalAction = Random.Next(90, 100);
        ChanceToAttack = Random.Next(30, 50);
        ChanceToMakeFriend = Random.Next(10, 50);
        ChanceToSuicide = Random.Next(1, 40);

        //=======================================//

        return this;
    }
    private void Modify()
    {
        CurrentSanity += Random.Next(-5, 5);
        CurrentHappiness += Random.Next(-5, 5);

        ChanceToNormalAction += Random.Next(-5, 5);
        ChanceToAttack += Random.Next(-5, 5);
        ChanceToFindingItem += Random.Next(-5, 5);
        ChanceToMakeFriend += Random.Next(-5, 5);
        ChanceToSuicide += Random.Next(-5, 5);
        ChanceToAccident += Random.Next(-5, 5);

        //=====================================//
        //Bloquear valores//
        CurrentHealth = Math.Clamp(CurrentHealth, 1, MaxHealth);
        CurrentSanity = Math.Clamp(CurrentSanity, 1, MaxSanity);
        CurrentHappiness = Math.Clamp(CurrentHappiness, 1, MaxHappiness);

        ChanceToNormalAction = Math.Clamp(ChanceToNormalAction, 1, 100);
        ChanceToAttack = Math.Clamp(ChanceToAttack, 1, 100);
        ChanceToFindingItem = Math.Clamp(ChanceToFindingItem, 1, 100);
        ChanceToSuicide = Math.Clamp(ChanceToSuicide, 1, 100);
        ChanceToAccident = Math.Clamp(ChanceToAccident, 1, 100);
    }

    public HGMessage GetRandomAction(HGMinigame configuration)
    {
        Modify();

        if (Random.Next(0, 100) < ChanceToNormalAction) //Chance de executar uma a��o normal
        {
            if (Random.Next(0, 100) < 70) //Executar uma a��o normal
            {
                return DefautMessages[0].GetRandomMessage(this, configuration);
            }
            else //Achar um item
            {
                return DefautMessages[4].GetRandomMessage(this, configuration);
            }
        }
        else if (Random.Next(0, 100) < ChanceToMakeFriend) //Chance de executar a��o de intera��o
        {
            return DefautMessages[3].GetRandomMessage(this, configuration);
        }
        else if (Random.Next(0, 100) < ChanceToFindingItem) //Chance de achar um item
        {
            return DefautMessages[4].GetRandomMessage(this, configuration);
        }
        else if (Random.Next(0, 100) < ChanceToAttack) //Chance de executar uma a��o de ataque
        {
            return DefautMessages[1].GetRandomMessage(this, configuration);
        }
        else if (Random.Next(0, 100) < ChanceToSuicide) //Chance de executar a��o de suicidio
        {
            return DefautMessages[2].GetRandomMessage(this, configuration);
        }
        else //Se n�o achar nada execute uma a��o normal
        {
            return DefautMessages[0].GetRandomMessage(this, configuration);
        }
    }

    public void AddPlayerViewed(HGPlayer playerViewed)
    {
        if (ViewedPlayers.Where(x => x != playerViewed).ToList().Count == 0)
            ViewedPlayers.Add(playerViewed);
    }

    public HGPlayer GetRandomViwedPlayer()
    {
        return ViewedPlayers[Random.Next(0, ViewedPlayers.Count - 1)];
    }
    public void AddFriend(HGPlayer friend)
    {
        List<HGFriend> playerFriends = new List<HGFriend>(Friends.Where(x => x.PlayerFriend != friend));

        foreach (HGFriend currentFriend in Friends)
        {
            if (currentFriend.PlayerFriend == friend)
            {
                Friends.Where(x => x.PlayerFriend == friend).First().RelationShipPercentage += Random.Next(5, 15);
                return;
            }
        }

        Friends.Add(new HGFriend() { PlayerFriend = friend, RelationShipPercentage = Random.Next(5, 15) });
    }
    public HGFriend GetRandomFriend()
    {
        return Friends[Random.Next(0, Friends.Count - 1)];
    }
    public HGFriend GetRandomFriend(HGPlayer except)
    {
        List<HGFriend> tempPlayers = new List<HGFriend>(Friends);
        tempPlayers.Remove(tempPlayers.Where(x => x.PlayerFriend == except).FirstOrDefault());

        return tempPlayers[Random.Next(0, Friends.Count - 1)];
    }
}