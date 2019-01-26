public class JumpForcePowerUp : PowerUp
{
    public override void Apply(Player player)
    {
        player.mJumpforceMultiplyer += m_Value;
    }
}
