using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class MineHability : MonoBehaviour
{
    public int miningPower = 10;
    public float miningCooldown = 0.5f;

    public TextMeshProUGUI hardnessText;
    public LayerMask dirtLayer;

    BreakableBlock block;
    RaycastHit2D hit;
    bool canHit = true;

    public SpriteRenderer plrHand;
    public static MineHability instance;
    public Animator animController;
    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dir = mousePos - transform.position;
        hit = Physics2D.Raycast(transform.position, dir, 2, dirtLayer);


        if (Input.GetMouseButtonDown(0))
        {
            Mine();
        }

        if (hit)
        {
            ShowUI(true);
            block = hit.transform.GetComponent<BreakableBlock>();

        }
        else
        {
            ShowUI(false);
        }
    }




    void ShowUI(bool state)
    {
        if (block)
        {

            hardnessText.enabled = state;
            hardnessText.text = block.blockName + ": " +block.blockLife + "/" + block.hardness;
        }


    }

    void Mine()
    {
        if (canHit)
        {
            animController.SetTrigger("Mine");
            MineCooldown();
            if (hit)
            {
                block.BreakBlock(miningPower);

            }
        }
      
    }
    async void MineCooldown()
    {
        canHit = false;

        await Task.Delay((int)(miningCooldown * 1000));

        canHit = true;
    }

    public void ChangeSprite(Sprite sprite)
    {
        plrHand.sprite = sprite;
    }
}