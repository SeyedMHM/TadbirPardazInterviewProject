import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
})
export abstract class SharedService<TModel> {
    protected controllerUrl: string = "";
    protected apiURL: string = "";
    protected httpClientService!: HttpClient;
    protected httpOptions = {
        headers: new HttpHeaders({
            'Content-Type': 'application/json'
        })
    }

    constructor() {
    }

    getPagedList(pageId: number = 1, pageSize: number = 5): Observable<any> {
        let url = `GetPagedList?pageId=${pageId}&pageSize=${pageSize}`;
        return this.httpClientService.get(this.apiURL + url)
            .pipe(
                catchError(this.errorHandler)
            )
    }

    getAll(): Observable<any> {
        return this.httpClientService.get(this.apiURL + 'GetAll')
            .pipe(
                catchError(this.errorHandler)
            )
    }

    create(model: TModel): Observable<any> {
        return this.httpClientService.post(this.apiURL + 'Create/', JSON.stringify(model), this.httpOptions)
            .pipe(
                catchError(this.errorHandler)
            )
    }

    get(id: number): Observable<any> {
        return this.httpClientService.get(this.apiURL + 'Get?id=' + id)
            .pipe(
                catchError(this.errorHandler)
            )
    }

    update(model: TModel): Observable<any> {
        return this.httpClientService.put(this.apiURL + 'Update', JSON.stringify(model), this.httpOptions)
            .pipe(
                catchError(this.errorHandler)
            )
    }

    delete(id: number) {
        return this.httpClientService.delete(this.apiURL + 'Delete?id=' + id, this.httpOptions)
            .pipe(
                catchError(this.errorHandler)
            )
    }

    errorHandler(error: any) {
        let errorMessage = '';
        if (error.error instanceof ErrorEvent) {
            errorMessage = error.error.message;
        }
        else {
            errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
        }
        return throwError(errorMessage);
    }
}