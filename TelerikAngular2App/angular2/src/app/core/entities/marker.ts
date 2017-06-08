export interface IMarker {
    id?: string;
    lat: number;
    lng: number;
    label: string;
    draggable: boolean;
    isOpen?: boolean;
    description?: string;
    IsVisited?: boolean;
    IsSaved?: boolean;
    CreatedOn?: Date;

}

export interface IMarkerToSave {
    Lat: number;
    Lng: number;
    Label: string;
    Description?: string;
}