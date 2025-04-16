using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{


  // Propriétaire du projectile. Référencé pour éviter la collision entre les le tireur et le projectile, son sens d'orientation et pour pouvoir être attribué au projectile.
  [SerializeField] GameObject Owner;
  [SerializeField] ObjectPool _objectPool;
  //Sens d'orientation du tireur. définie ici pour debug.
  private int Direction;

  // Debug.
  void Start()
  {
    OnFire();
  }
  /// <summary>
  /// Fonction a appeler pour tirer un projectile.
  /// </summary>
  public void OnFire()
  {
    // Cherche à obtenir la référence du script du propriétaire pour obtenir son sens d'orientation.
    if (Owner.TryGetComponent(out CharacterMovement characterscript))
    {
      Direction = characterscript.Direction;
    }
    else if (Owner.TryGetComponent(out MonsterMovement monsterscript))
    {
      //Direction = monsterscript.Direction;
    }

    // SetActive le projectile de la pool devant le tireur en fonction de son orientation.
    GameObject Projectile = _objectPool.GetPooledObject();
    if (Projectile != null)
    {
      Projectile.transform.position = new Vector2(transform.position.x, transform.position.y) + Vector2.right * 0.1f * Direction;
      Projectile.transform.rotation = Owner.transform.rotation;
      Projectile.SetActive(true);
    }


    // Donne la référence du tireur et son orientation au projectile instancié.
    if (Projectile.TryGetComponent(out ProjectileClass projectilescript))
    {
      projectilescript.Direction = Direction;
      projectilescript.Owner = Owner;
    }

  }
}