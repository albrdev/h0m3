public class MovementSpeedPowerUp : PowerUp
{
    public override void Apply(Player player)
    {
        player.mMovementspeedMultiplyer += m_Value;
    }
}
