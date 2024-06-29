public class Muck : Dirty
{
    public override void Clean()
    {
        if (_player.Inventory.Item is ItemWetMop)
        {
            _spriteOpacity.MakeTransparent();
        }
    }
}
