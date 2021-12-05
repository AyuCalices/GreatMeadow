using Features.Character_Namespace;
using Features.Maze_Namespace.Tiles;
using UnityEngine;
using Utils.Event_Namespace;
using Utils.Variables_Namespace;

public class Hatch : InteractableBehaviour
{
    [SerializeField] private TileList_SO tileList;
    [SerializeField] private Vector2Variable hatchPosition;
    [SerializeField] private Vector2Variable hatchSpawnPos;
    [SerializeField] private Vector2Variable playerSpawnPos;
    [SerializeField] private IntVariable width;
    [SerializeField] private IntVariable height;
    [SerializeField] private GameEvent onLoadWinMenu;
    private Animator animator;
    private static readonly int JumpInHatch = Animator.StringToHash("JumpInHatch");

    /**
    * Set the Hatch Position at the opposite of the starting position.
    */
    public void SetHatchPosition() {
        int startX = (int) playerSpawnPos.vec2Value.x;
        int startY = (int) playerSpawnPos.vec2Value.y;
           
        int endX = width.intValue - 1 - startX; 
        int endY = height.intValue - 1 - startY;

        //hatchSpawnPos.vec2Value = playerSpawnPos.vec2Value; //for testing
        hatchSpawnPos.vec2Value = new Vector2(endX, endY);
        transform.position = hatchPosition.vec2Value;
        tileList.GetTileAt(endX, endY).RegisterInteractable(this);
    }

    public override void Interact(PlayerController2D playerController)
    {
        GetComponent<AudioSource>().Play();
        animator = GetComponent<Animator>();
        animator.SetTrigger(JumpInHatch);
        playerController.GetComponent<SpriteRenderer>().enabled = false;
    }

    //gets called by an animator event
    public void LoadWinMenu()
    {
        onLoadWinMenu.Raise();
    }
}
