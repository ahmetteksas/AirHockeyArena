using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skills : MonoBehaviour
{
    public Sound sounds;
    public GameObject skill_1_button;
    public GameObject skill_2_button;
    public GameObject skill_3_button;
    public GameObject skill_4_button;
    //Skill 1
    public GameObject Ice_cube;
    //Skill 2
    public GameObject red_left_obj;
    public GameObject red_right_obj;
    public GameObject goal;
    //Skill 3
    public GameObject Disc;
    //Skill 4
    public GameObject Disc_ice;
    
    void Start()
    {
        
    }
    public void skill1_freeze_p2_button()
    {
        StartCoroutine("skill1_freeze_p2");
        skill_1_button.GetComponent<Button>().interactable = false;
    }

    public void skill_2_biggersize_p2_button()
    {
        StartCoroutine("skill2_biggersize_p2");
        skill_2_button.GetComponent<Button>().interactable = false;
    }
    public void skill_3_invincible_button()
    {
        StartCoroutine("skill3_invincible_disc");
        skill_3_button.GetComponent<Button>().interactable = false;
    }

    public void skill4_disc_freeze_button()
    {
        StartCoroutine("skill4_disc_freeze");
        skill_4_button.GetComponent<Button>().interactable = false;
    }

    public IEnumerator skill1_freeze_p2()
    {
        Variables.diskmovecontrol = true;
        sounds.ice_freeze_sound();
        yield return new WaitForSecondsRealtime(0.15f);
        Ice_cube.SetActive(true);
        yield return new WaitForSecondsRealtime(3);
        Variables.diskmovecontrol = false;
        sounds.ice_break_sound();
        Ice_cube.SetActive(false);
    }

    public IEnumerator skill2_biggersize_p2()
    {
        sounds.wall_bigger_sound();

        yield return new WaitForSecondsRealtime(0.2f);

        red_left_obj.transform.localPosition = new Vector3(red_left_obj.transform.localPosition.x, red_left_obj.transform.localPosition.y, -0.5161f);
        red_left_obj.transform.localScale = new Vector3(red_left_obj.transform.localScale.x, 73.42474f, red_left_obj.transform.localScale.z);

        red_right_obj.transform.localPosition = new Vector3(red_right_obj.transform.localPosition.x, red_right_obj.transform.localPosition.y, 1.8605f);
        red_right_obj.transform.localScale = new Vector3(red_right_obj.transform.localScale.x, 73.10495f, red_right_obj.transform.localScale.z);

        goal.transform.localScale = new Vector3(goal.transform.localScale.x, 130f, goal.transform.localScale.z);
       

        yield return new WaitForSecondsRealtime(3);

        sounds.wall_smaller_sound();

        yield return new WaitForSecondsRealtime(0.2f);

        red_left_obj.transform.localPosition = new Vector3(red_left_obj.transform.localPosition.x, red_left_obj.transform.localPosition.y, 0.6647601f);
        red_left_obj.transform.localScale = new Vector3(red_left_obj.transform.localScale.x, 100f, red_left_obj.transform.localScale.z);

        red_right_obj.transform.localPosition = new Vector3(red_right_obj.transform.localPosition.x, red_right_obj.transform.localPosition.y, 0.6647601f);
        red_right_obj.transform.localScale = new Vector3(red_right_obj.transform.localScale.x, 100f, red_right_obj.transform.localScale.z);

        goal.transform.localScale = new Vector3(goal.transform.localScale.x, 100f, goal.transform.localScale.z);
    }

    public IEnumerator skill3_invincible_disc()
    {
        sounds.invicible_sound();
        Disc.GetComponent<MeshRenderer>().enabled = false;
        yield return new WaitForSecondsRealtime(3);
        Disc.GetComponent<MeshRenderer>().enabled = true;
    }

    public IEnumerator skill4_disc_freeze()
    {
        sounds.ice_freeze_sound();
        yield return new WaitForSecondsRealtime(0.15f);
        Disc_ice.SetActive(true);
        Disc.GetComponent<MeshCollider>().enabled = false;
        Disc.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);

        yield return new WaitForSecondsRealtime(3);

        sounds.ice_break_sound();
        Disc_ice.SetActive(false);
        Disc.GetComponent<MeshCollider>().enabled = true;
    }

}
