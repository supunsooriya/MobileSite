import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class MobileItemService {
  private API_URL = environment.BaseUrl + "api/";
  storeRef: object;

  constructor(private http: HttpClient) { }

  GetMobileItem(): Observable<any> {
    return this.http.get<any>(
      this.API_URL + "MobileItems"
    );
  }


}
