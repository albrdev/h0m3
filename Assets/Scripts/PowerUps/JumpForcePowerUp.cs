public class JumpForcePowerUp : PowerUp
{
    public override void Apply(Player player)
    {
        player.m_JumpHeightMultiplier += m_Value;
    }
}
