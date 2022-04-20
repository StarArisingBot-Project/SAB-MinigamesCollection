namespace StarArisingBot.Minigames.HungerGames
{
    public class SuicideMessagePack : HGBaseMessagePack
    {
        protected override void BuildPack()
        {
            SuicideMessages();
            TragediesMessages();
            ItemTragediesMessages();

            Configuration.PlayersController.Kill(PlayerTarget1);
        }

        private void SuicideMessages()
        {
            messages.AddRange(new HGMessage[] {
                   new HGMessage($"**{PlayerTarget1.Name}** não aguenta toda a pressão da ilha e se enforca em uma arvore.", HGMessageType.TragedyAction),
            });
        }

        private void TragediesMessages()
        {
            messages.AddRange(new HGMessage[] {
                   new HGMessage($"**{PlayerTarget1.Name}** cai em um buraco e acaba morrendo.", HGMessageType.TragedyAction),
                   new HGMessage($"**{PlayerTarget1.Name}** cai em um lago congelado e se afoga.", HGMessageType.TragedyAction),
                   new HGMessage($"**{PlayerTarget1.Name}** escala uma árvore, mas se desequilibra e cai para a morte.", HGMessageType.TragedyAction),
                   new HGMessage($"**{PlayerTarget1.Name}** tropeça em uma pedra no penhasco e cai para morte.", HGMessageType.TragedyAction),
                   new HGMessage($"**{PlayerTarget1.Name}** vai nadar na praia, mas é puxado pelas ondas e desaparece.", HGMessageType.TragedyAction),
                   new HGMessage($"**{PlayerTarget1.Name}** vai para muito longe, seu corpo é encontrado horas depois por **{PlayerTarget2.Name}**.", HGMessageType.TragedyAction),
                   new HGMessage($"**{PlayerTarget1.Name}** foi picado até a morte após cutucar um ninho de marimbondo.", HGMessageType.TragedyAction),
                   new HGMessage($"**{PlayerTarget1.Name}** morre de frio.", HGMessageType.TragedyAction),
                   new HGMessage($"**{PlayerTarget1.Name}** morre de fome.", HGMessageType.TragedyAction),
                   new HGMessage($"**{PlayerTarget1.Name}** morre de uma doença desconhecida.", HGMessageType.TragedyAction),
                   new HGMessage($"**{PlayerTarget1.Name}** viola a regra de tentar fugir da ilha e é desintegrado por drones teleguiados.", HGMessageType.TragedyAction),
            });
        }

        private void ItemTragediesMessages()
        {
            if (!PlayerTarget1.Inventory.HasItems && PlayerTarget1.Inventory.TotalWeaponsCount <= 0) //Se o jogador tiver itens
                return;

            for (int i = 0; i < PlayerTarget1.Inventory.TotalWeaponsCount; i++)
            {
                messages.Add(new HGMessage(PlayerTarget1.Inventory.GetRandomItem<HGWeaponItemBase>().GetRandomSuicideMessage(PlayerTarget1, PlayerTarget2), HGMessageType.TragedyAction));
            }
        }
    }
}
