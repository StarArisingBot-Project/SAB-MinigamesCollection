using System.Collections.Generic;

namespace StarArisingBot.Minigames.HungerGames
{
    public class HGSworldItem : HGWeaponItemBase
    {
        public HGSworldItem()
        {
            Name = "Espada";
            WordArticle = "a";
            PossessivePronoun = "sua";

            Type = HGItemType.Weapon;
        }

        protected override IEnumerable<string> BuildFindingMessages()
        {
            return new string[]
            {
                "{0} encontra uma espada próximo ao seu acampamento.",
                "{0} faz uma espada.",
                "{0} encontrou uma espada enquanto explorava a floresta.",
                "{0} encontrou uma espada quando caminhava pela praia.",
            };
        }

        protected override IEnumerable<string> BuildDayMessages()
        {
            return new string[]
            {
                "{0} tenta caçar alguns animais com sua espada.",
                "{0} treina movimentos de luta com sua espada.",
                "{0} faz melhorias em sua espada.",
                "{0} limpa sua espada.",
            };
        }

        protected override IEnumerable<string> BuildNightMessages()
        {
            return new string[]
            {
                "{0} se preparando para dormir, deixa a espada do seu lado a noite.",
                "{0} esconde sua espada na floresta.",
                "{0} atentamente pela floresta com sua espada.",
            };
        }

        protected override IEnumerable<string> BuildAttackMessages()
        {
            return new string[]
            {
                "{0} encontra {1} na floresta, em um movimento rápido {0} parte para cima com sua espada e consegue fazer um corte profundo em {1} que sai correndo dali.",
                "{0} vê {1} ao longe, ele se aproxima e em um movimento furtivo tenta enfiar sua espada no crânio de {1} que consegue notar sua presença a tempo e foge dali com um pequeno corte no rosto.",
                "{0} explorando a floresta vê {1} em sua barraca preparando algumas coisas, ao ver que ele está sozinho {0} vai rapidamente para seu acampamento onde em um ataque surpresa consegue acertar {1} que tenta revidar mas não consegue."
            };
        }

        protected override IEnumerable<string> BuildAttackFriendMessages()
        {
            return new string[]
            {
                "{0} vendo que para vencer teria que matar seus amigos, com um olhar triste parte para cima de {1} que não consegue se defender, um corte de espada é dado em seu rosto e pela piedade de {0}, ele consegue escapar.",
            };
        }

        protected override IEnumerable<string> BuildMurderMessages()
        {
            return new string[]
            {
                "{0} com sua espada, corta as mãos, os pés, os braços e as pernas de {1} que é deixado para morrer na floresta.",
                "{0} sem piedade, enfia sua espada no crânio de {1} que é partido ao meio depois de alguns segundos.",
                "{0} encontra o acampamento de {1}, furtivamente, {0} invade o acampamento e ao encontrar o {1} preparando algumas armas {0} o mata com um corte profundo no coração com sua espada e depois rouba todos os seus pertences.",
                "{0} sequestra o {1} em busca de algumas informações sobre os outros tributos, vendo que não iria conseguir nada, {0} sem piedade, corta os pulsos de {1} o deixando para morrer na floresta."
            };
        }

        protected override IEnumerable<string> BuildMurderFriendMessages()
        {
            return new string[]
            {
                "{0} vendo que não teria escolha, com sua espada parte para cima de seu amigo, {1} não consegue se defender dos ataques de {0} e acaba tendo seu coração atravessado pela lâmina da espada.",
                "{0} faz um trato com {1} de uma batalha final entre os dois, com sua espada e a dor de atacar um amigo {0} parte para cima e em um movimento rápido consegue atravessar sua espada no abdome de {1} que cai em seus braços, como um último suspiro, {1} diz a última coisa que queria fazer para {0}.",
                "{1} encontra {0} na barraca, vendo que algo estava errado ele pergunta ao seu amigo o que está acontecendo, {0} não responde e vai em direção a ele. Após uma pequena conversa {1} sente uma dor muito forte em seu abdome e nota que {0} não era um amigo de verdade e havia enfiado sua espada em seu peito, {1} com lagrimas nos olhos caí morto no chão.",
                "{0} e {1} indo caçar pela floresta, conversam um pouco sobre o futuro e em um momento de distração, {0} enfia sua espada na garganta de {1} enquanto corriam pela floresta. Pelo sentimento de traição de um amigo, {1} lacrimejar cai no chão e não consegue resistir aos ferimentos."
            };
        }

        protected override IEnumerable<string> BuildSuicideMessages()
        {
            return new string[]
            {
                "{0} não vendo mais um futuro melhor na ilha, como último ato, enfia sua espada em seu peito. Ele morre distante de todos da ilha.",
                "{0} em um movimento falho, acaba cortando sua própria garganta com sua espada, sua morte não acontece rapidamente fazendo ele entrar em um estado de loucura enquanto morte.",
                "{0} treinando com sua espada acaba se empolgando e acidentalmente, acaba enfiando sua espada no próprio peito."
            };
        }
    }
}
