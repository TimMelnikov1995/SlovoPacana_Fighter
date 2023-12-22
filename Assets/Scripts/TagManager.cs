using UnityEngine;

public class LayersTags
{
    public static readonly LayerMask ARROW_LAYER = LayerMask.GetMask("UI_Arrows");
    public static readonly LayerMask PF_LAYER = LayerMask.GetMask("Playing_Field");
    public static readonly LayerMask HIDER_LAYER = LayerMask.GetMask("UI_Hideable");
}

public class NamesTags
{
    public static readonly string MAIN_MENU_SCENE = "MainMenuScene";
    public static readonly string ARENA_1_SCENE = "Arena1Scene";
    public static readonly string ARENA_2_SCENE = "Arena2Scene";
    public static readonly string ARENA_3_SCENE = "Arena3Scene";

    public static readonly string PLAYING_FIELD = "PlayingField";
    public static readonly string BGM_TAG = "GameMusic";
}

public class AnimationTags
{
    public const string MOVEMENT = "Movement";
    public const string ROTATION = "Rotation";

    public const string PUNCH_1_TRIGGER = "Punch1";
    public const string PUNCH_2_TRIGGER = "Punch2";
    public const string PUNCH_3_TRIGGER = "Punch3";

    public const string KICK_1_TRIGGER = "Kick1";
    public const string KICK_2_TRIGGER = "Kick2";

    public const string ATTACK_1_TRIGGER = "Attack1";
    public const string ATTACK_2_TRIGGER = "Attack2";
    public const string ATTACK_3_TRIGGER = "Attack3";

    public const string CROUCH_ANIMATION = "Crouch";

    public const string BLOCK_ANIMATION = "Block";

    public const string IDLE_ANIMATION = "Idle";

    public const string KNOCK_DOWN_TRIGGER = "KnockDown";
    public const string STAND_UP_TRIGGER = "StandUp";
    public const string HIT_TRIGGER = "Hit";
    public const string DEATH_TRIGGER = "Death";
}

public class AxisTags
{
    public const string HORIZONTAL_AXIS = "Horizontal";
    public const string VERTICAL_AXIS = "Vertical";
    public const string MOUSE_X = "Mouse X";
    public const string MOUSE_Y = "Mouse Y";
}

public class Tags
{
    public const string GROUND_TAG = "Ground";
    public const string PLAYER_TAG = "Player";
    public const string ENEMY_TAG = "Enemy";

    public const string LEFT_ARM_TAG = "LeftArm";
    public const string LEFT_LEG_TAG = "LeftLeg";
    public const string UNTAGGED_TAG = "Untagged";
    public const string MAIN_CAMERA_TAG = "MainCamera";
    public const string HEALTH_UI = "HealthUI";
}