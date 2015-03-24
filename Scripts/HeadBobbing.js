#pragma strict

 private var timer = 0.0; 
 var bobbingSpeed = 0.18; 
 var bobbingAmount = 0.2; 
 var midpoint = 2.0; 
 
 var clip : AudioSource;
 
 function FixedUpdate () { 
    var waveslice = 0.0; 
    var horizontal = Input.GetAxis("Horizontal"); 
    var vertical = Input.GetAxis("Vertical"); 
    if (Mathf.Abs(horizontal) == 0 && Mathf.Abs(vertical) == 0) { 
       timer = 0.0; 
    } 
    else { 
       waveslice = Mathf.Sin(timer); 
       timer = timer + bobbingSpeed; 
       if (timer > Mathf.PI * 2) { 
          timer = timer - (Mathf.PI * 2);   
       } 
    } 
    
    if(waveslice > 0.9) {
    	GetComponent.<AudioSource>().Play();
    }
    
    if (waveslice != 0) { 
       var translateChange = waveslice * bobbingAmount; 
       var totalAxes = Mathf.Abs(horizontal) + Mathf.Abs(vertical); 
       totalAxes = Mathf.Clamp (totalAxes, 0.0, 1.0); 
       translateChange = totalAxes * translateChange; 
       transform.localPosition.y = midpoint + translateChange; 
    } 
    else { 
       	transform.localPosition.y = midpoint; 
    } 
 }