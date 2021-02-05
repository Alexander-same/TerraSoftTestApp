import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TextRequest } from '../models/text-request.model';
import { TextResponse } from '../models/text-response.model';
 
@Injectable({providedIn:'root'})
export class ApiService {
 
  baseURL: string = "http://localhost:5000/api/";
 
  constructor(private http: HttpClient) {
  }
 
  getTypes(): Observable<string[]> {
    return this.http.get<string[]>(this.baseURL + 'TextMetric')
  }
 
  sendText(textRequest: TextRequest): Observable<any>{
    const headers = { 'content-type': 'application/json'};
    const body = JSON.stringify(textRequest);

    return this.http.post(this.baseURL + 'TextMetric', body,{'headers':headers});
  };
}