public class MovementSpeedPowerUp : PowerUp
{
    public override void Apply(Player player)
    {
        player.m_MovementspeedMultiplyer += m_Value;
    }
}
