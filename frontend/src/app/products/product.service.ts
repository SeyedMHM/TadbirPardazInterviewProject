import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { ProductCreateOrUpdateCommand } from './models/product-create-or-update-command';

@Injectable({
    providedIn: 'root'
})
export class ProductService {

    private apiURL = "https://localhost:7122/Products/";

    httpOptions = {
        headers: new HttpHeaders({
            'Content-Type': 'application/json'
        })
    }

    constructor(private httpClient: HttpClient) { }

    getPagedList(pageId: number = 1, pageSize: number = 5): Observable<any> {
        let url = `GetPagedList?pageId=${pageId}&pageSize=${pageSize}`;
        return this.httpClient.get(this.apiURL + url)
            .pipe(
                catchError(this.errorHandler)
            )
    }

    getAll(): Observable<any> {
        return this.httpClient.get(this.apiURL + 'GetAll')
            .pipe(
                catchError(this.errorHandler)
            )
    }

    create(model: ProductCreateOrUpdateCommand): Observable<any> {
        return this.httpClient.post(this.apiURL + 'Create/', JSON.stringify(model), this.httpOptions)
            .pipe(
                catchError(this.errorHandler)
            )
    }

    get(id: number): Observable<any> {
        return this.httpClient.get(this.apiURL + 'Get?id=' + id)
            .pipe(
                catchError(this.errorHandler)
            )
    }

    update(model: ProductCreateOrUpdateCommand): Observable<any> {
        return this.httpClient.put(this.apiURL + 'Update', JSON.stringify(model), this.httpOptions)
            .pipe(
                catchError(this.errorHandler)
            )
    }

    delete(id: number) {
        return this.httpClient.delete(this.apiURL + 'Delete?id=' + id, this.httpOptions)
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