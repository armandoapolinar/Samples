using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip coinSFX;
    [SerializeField] AudioClip doubleJumpSFX;
    [SerializeField] AudioClip powerupShieldSFX;
    [SerializeField] AudioClip powerupDoubleJumpSFX;
    [SerializeField] AudioClip shieldBreakSFX;
    [SerializeField] AudioClip jumpSFX;
    [SerializeField] AudioClip landSFX;
    [SerializeField] AudioClip gameOverHitSFX;






    // Start is called before the first frame update

    public void PlaySFX(string clipToPlay)
    {
        switch(clipToPlay)
        {
            case "Coin":
                audioSource.clip = coinSFX;
                break;
            case "Jump":
                audioSource.clip = jumpSFX;
                break;
            case "DoubleJump":
                audioSource.clip = doubleJumpSFX;
                break;
            case "PowerupDoubleJump":
                audioSource.clip = powerupDoubleJumpSFX;
                break;
            case "PowerupShield":
                audioSource.clip = powerupShieldSFX;
                break;
            case "ShieldBreak":
                audioSource.clip = shieldBreakSFX;
                break;
            case "Land":
                audioSource.clip = landSFX;
                break;
            case "GameOverHit":
                audioSource.clip = gameOverHitSFX;
                break;
        }
        audioSource.Play();
    }

}
