using System.Collections.Generic;

namespace StarArisingBot.Minigames.HungerGames
{
    public class HGBowItem : HGWeaponItemBase
    {
        public HGBowItem()
        {
            Name = "Arco";
            WordArticle = "o";
            PossessivePronoun = "seu";

            Type = HGItemType.Weapon;
        }

        protected override IEnumerable<string> BuildFindingMessages()
        {
            return new string[]
            {
                "{0} faz um arco.",
                "{0} encontra um arco na floresta.",
                "{0} encontra um arco na praia.",
            };
        }

        protected override IEnumerable<string> BuildDayMessages()
        {
            return new string[]
            {
                "{0} caça alguns animais com seu arco na floresta.",
                "{0} treina tiro ao alvo com seu arco.",
                "{0} treinando com seu arco, acaba acidentalmente errando sua flecha que vai com muita velocidade em direção à floresta.",
            };
        }

        protected override IEnumerable<string> BuildNightMessages()
        {
            return new string[]
            {
                "{0} treina com seu arco.",
                "{0} vê {1} ao longe e tenta atirar uma flecha nele, mas acaba errando.",
                "{0} coloca seu machado em um local seguro.",
                "{0} faz algumas flechas para seu arco.",
                "{0} faz algumas melhorias em seu arco."
            };
        }

        protected override IEnumerable<string> BuildAttackMessages()
        {
            return new string[]
            {
                "{0} ao ver {1} ao longe, prepara seu arco e passa alguns segundo mirando e finalmente dispara a flecha que passa de raspão por {1} fazendo apenas uma pequena ferida.",
                "{0} com seu arco, atira uma flecha em direção ao {1} que tem sua perna atravessada por uma flecha.",
                "{0} treinando com seu arco, acaba acidentalmente errando sua flecha que vai com muita velocidade em direção à floresta. A flecha acaba acertando {1} que tem seu abdome atravessado por uma flecha."
            };
        }

        protected override IEnumerable<string> BuildAttackFriendMessages()
        {
            return new string[]
            {
                "{0} acidentalmente acaba acertando uma flechada no {1} que começa a gritar de dor.",
                "{0} observa ao longe seu amigo {1} caçando alguns animais na floresta, friamente, {0} prepara seu arco e atira uma flecha que acaba acerta perfeitamente a perna de {1} que começa a gritar de dor.",
            };
        }

        protected override IEnumerable<string> BuildMurderMessages()
        {
            return new string[]
            {
                "{0} na floresta, observa {1} ao longe caçando alguns animais, friamente, {0} prepara seu arco e atira uma flecha que acaba acerta perfeitamente a cabeça de {1} que começa a gritar de dor e eventualmente morrendo.",
            };
        }

        protected override IEnumerable<string> BuildMurderFriendMessages()
        {
            return new string[]
            {
                 "{0} observa ao longe seu amigo {1} caçando alguns animais na floresta, com lagrimas nos olhos, {0} prepara seu arco e atira uma flecha que acaba acertando o coração de {1} que começa a gritar de dor e eventualmente, morrendo.",
            };
        }

        protected override IEnumerable<string> BuildSuicideMessages()
        {
            return new string[]
            {
                "{0} triste e desamparado, prepara o seu arco e atira uma flecha em sua própria cabeça. Sua morte chega eventualmente.",
                "Por um erro de cálculo, {0} atira uma flecha para cima tentando pegar um pássaro, mas acaba errando. Sua flecha volta uma velocidade absurda e atinge seu crânio, sua morte é iminente."
            };
        }
    }
}
