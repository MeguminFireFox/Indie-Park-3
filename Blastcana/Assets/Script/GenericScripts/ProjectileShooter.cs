using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{

  // Propriétaire du projectile. Référencé pour éviter la collision entre les le tireur et le projectile, son sens d'orientation et pour pouvoir être attribué au projectile.
  [SerializeField] GameObject Owner;
  [SerializeField] GameObject ProjectilePrefab;

  //Sens d'orientation du tireur.
  private int direction;


  // Fonction a appeler pour tirer un projectile.
  public void OnFire()
  {
    // Cherche à obtenir la référence du script du propriétaire pour obtenir son sens d'orientation.
    /*  if(Owner.TryGetComponent(out CharacterAttack characterscript)){
      direction = characterscript.direction;
      }
      else if(Owner.TryGetComponent(out MonsterRange monsterscript)){
      direction = monsterscript.direction;
      }
      */
    // Instancie le projectile en devant le tireur en fonction de son orientation.
    var proj = Instantiate(ProjectilePrefab, new Vector2(transform.position.x, transform.position.y) + Vector2.right * 10 * direction, Quaternion.identity);

    // Donne la référence du tireur au projectile instancié.
    /*if(proj.TryGetComponent(out Projectile projectilescript)){
      projectilescript.owner = Owner;
    }
    */
  }
}