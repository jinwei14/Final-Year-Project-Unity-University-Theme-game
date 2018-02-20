using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//as for code reusable set the damage interface 
//for more object to use
public interface interfaceDam {

    void TakeDamage(float damage, RaycastHit hit);
}
