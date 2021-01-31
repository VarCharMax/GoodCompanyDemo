import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';
import { Computer } from '../models/computer';

@Injectable({ providedIn: 'root' })
export class ComputerService extends BaseService {
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    super(http, baseUrl);
  }

  getData<Computer>(): Observable<Computer> {
    const url = this.baseUrl + 'api/computer';

    return this.http.get<Computer>(url);
  }

  get<Computer>(id: string): Observable<Computer> {
    const url = this.baseUrl + 'api/computer/' + id;
    return this.http.get<Computer>(url);
  }

  put<Computer>(item): Observable<Computer> {
    const url = this.baseUrl + 'api/computer/' + item.id;
    return this.http.put<Computer>(url, item);
  }

  post<Computer>(item): Observable<Computer> {
    const url = this.baseUrl + 'api/computer/' + item.id;
    return this.http.post<Computer>(url, item);
  }

  getComputers<Computer>(): Observable<Computer> {
    const url = this.baseUrl + 'api/computer';

    return this.http.get<Computer>(url);
  }
}
