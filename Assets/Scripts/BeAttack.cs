using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeAttack : MonoBehaviour {
    public Life LifeScript; // Life's script
    public GameObject damageEffect;
    public AudioSource damageSound;

    void Start() {
        this.hideDamageEffect();
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "throwTool") {
            this.LifeScript.img.fillAmount -= 0.1f; //扣血

            this.showDamageEffect();
            Invoke("hideDamageEffect", 0.3f); // hide damage effect after 0.3s
        }
    }

    void showDamageEffect() {
        this.damageEffect.SetActive(true);
        this.damageSound.Play();
    }

    void hideDamageEffect() {
        this.damageEffect.SetActive(false);
    }

}
