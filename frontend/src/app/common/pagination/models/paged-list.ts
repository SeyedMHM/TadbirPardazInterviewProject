export interface IPagedList<TModel> {
    totalCount: number;
    pageSize: number;
    currentPage: number;
    totalPages: number;
    hasPrevious: boolean;
    hasNext: boolean;
    items: TModel[];
}

export class PagedList<TModel> implements IPagedList<TModel> {
    totalCount!: number;
    pageSize!: number;
    currentPage!: number;
    totalPages!: number;
    hasPrevious!: boolean;
    hasNext!: boolean;
    items!: TModel[];
}