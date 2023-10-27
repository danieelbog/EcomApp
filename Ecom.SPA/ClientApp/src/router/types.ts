import { RouteMeta } from "vue-router";

export interface IRouteMeta extends RouteMeta {
    allowAnonymous: boolean;
    layoutType: LayoutType;
    pageTitle: string;
    showInNavigation: boolean;
}

export enum LayoutType {
    noLayout = 1,
    basicLayout = 2
}
