import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export abstract class BaseService {
  constructor(protected http: HttpClient, protected baseUrl: string) {}

  abstract getData<Computer>(): Observable<Computer>;
  abstract get<T>(id: string): Observable<T>;
  abstract put<T>(id: string, item: T): Observable<T>;
  abstract post<T>(item: T): Observable<T>;
}
