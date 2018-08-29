import { AbstractControl } from '@angular/forms';

export function ValidateTz(control: AbstractControl) {
 let total = 0;
 let tz=control.value
    let i
    for (i = 0; i < 9; i++) {
        let x = (((i % 2) + 1) * tz.charAt(i));
        total +=Math.floor(x/10) + x%10;
    }
if(total % 10 == 0)
return null;
return {ValidateTz:true}
}
