import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from '../../../../node_modules/rxjs';
import { User } from '../models/user';
@Injectable({
  providedIn: 'root'
})
export class AddUserService {
 configUrl:string="http://localhost:3500/api/user"
  constructor(private httpClient:HttpClient) { }

addUser(newUser:User):Observable<User>{

return this.httpClient.post<User>(this.configUrl,newUser);

}


}
