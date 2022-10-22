export interface IPagedListMetadata {
    currentPage: number;
    hasNext: number;
    hasPrevious: number;
    items: any;
    pageSize: number;
    totalCount: number;
    totalPages: number;
}

export class PagedListMetadata implements IPagedListMetadata {
    currentPage!: number;
    hasNext!: number;
    hasPrevious!: number;
    items!: any;
    pageSize!: number;
    totalCount!: number;
    totalPages!: number;
}