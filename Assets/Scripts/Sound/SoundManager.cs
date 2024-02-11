using UnityEngine;

namespace Zong.Sound
{
    public class SoundManager : Singleton<MonoBehaviour>
    {
        [SerializeField] private AudioSource uiAudioSource;
        [SerializeField] private AudioClip panelOpenSound;
        [SerializeField] private AudioClip panelCloseSound;
        [SerializeField] private AudioClip itemPickupSound;
        [SerializeField] private AudioClip itemDropSound;
        [SerializeField] private AudioClip boxASound;
        [SerializeField] private AudioClip boxBSound;
        [SerializeField] private AudioClip boxCSound;

        private void PlaySoundEffect(AudioSource audioSource, AudioClip audioClip)
        {
            audioSource.clip = audioClip;
            audioSource.Play();
        }

        public void PlayPanelOpenSound() 
        {
            PlaySoundEffect(uiAudioSource, panelOpenSound);
        }
        public void PlayPanelCloseSound() 
        {
            PlaySoundEffect(uiAudioSource, panelCloseSound);
        }
        public void PlayItemPickupSound(AudioSource audioSource) 
        {
            PlaySoundEffect(audioSource, itemPickupSound);
        }
        public void PlayItemDropSound(AudioSource audioSource) 
        {
            PlaySoundEffect(audioSource, itemDropSound);
        }
        public void PlayBoxASound(AudioSource audioSource) 
        {
            PlaySoundEffect(audioSource, boxASound);
        }
        public void PlayBoxBSound(AudioSource audioSource) 
        {
            PlaySoundEffect(audioSource, boxBSound);
        }
        public void PlayBoxCSound(AudioSource audioSource) 
        {
            PlaySoundEffect(audioSource, boxCSound);
        }
    }
}
