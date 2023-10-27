type ListenerFunction = (...eventData: any) => void;

export class EventBus {
    listeneres: Record<string, Array<ListenerFunction>>;

    constructor() {
        this.listeneres = {};
    }

    on(event: string, listener: ListenerFunction): void {
        this.listeneres[event] = this.listeneres[event] || [];

        if (this.listeneres[event].indexOf(listener) !== -1) return;

        this.listeneres[event].push(listener);
    }

    off(event: string, listener: ListenerFunction): void {
        if (!this.listeneres[event]) return;

        const index = this.listeneres[event].indexOf(listener);
        if (index == -1) return;

        this.listeneres[event].splice(index, 1);
    }

    emit(event: string, ...eventData: any): void {
        if (!this.listeneres[event] || this.listeneres[event].length == 0) return;

        const copy = this.listeneres[event].slice();
        copy.forEach((listener) => {
            listener(...eventData);
        });
    }
}
