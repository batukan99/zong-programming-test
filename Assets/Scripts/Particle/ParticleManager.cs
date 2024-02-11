
using UnityEngine;

namespace Zong.Particle
{
    public class ParticleManager : Singleton<MonoBehaviour>
    {

        #region Public Methods
        public void CreateEtheralParticle(Transform parent)
        {
            var particle = Singleton<PoolManager>.Instance.GetEtheralParticleObject(Vector3.zero, Quaternion.identity, parent);
            particle.gameObject.SetActive(true);
            particle.Emit(particle.particleCount);
            particle.Play();
        }

        public void CreateSparkParticle(Transform parent)
        {
            var particle = Singleton<PoolManager>.Instance.GetSparkParticleObject(Vector3.zero, Quaternion.identity, parent);
            particle.gameObject.SetActive(true);
            particle.Emit(particle.particleCount);
            particle.Play();
        }
        #endregion
    }

}

