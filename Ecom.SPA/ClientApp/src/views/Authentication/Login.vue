<template>
    <div class="container p-3 pt-lg-5">
        <h2 class="text-center my-3">Login</h2>
        <div class="row">
            <div class="col-12 col-lg-4"></div>
            <div class="col-12 col-lg-4">
                <div class="alert alert-danger d-flex flex-row align-items-center error-messages">
                    <i class="material-icons material-icon-24">report_problem</i>
                    <span>Error</span>
                </div>
                <div class="mb-3">
                    <label for="inputEmail" class="form-label">Email address</label>
                    <input type="email" class="form-control" id="inputEmail" aria-describedby="emailHelp">
                </div>
                <div class="mb-3">
                    <label for="inputPassword" class="form-label">Password</label>
                    <input type="password" class="form-control" id="inputPassword">
                </div>
                <div class="mb-3 form-check">
                    <input type="checkbox" class="form-check-input" id="exampleCheck1">
                    <label class="form-check-label" for="exampleCheck1">Remeber me</label>
                </div>
                <div class="mt-3">
                    <button class="btn btn-primary w-100">Login</button>
                    <a href="#" class="text-center">
                        <p class="p-2">Or Register</p>
                    </a>
                </div>
            </div>
        </div>
    </div>
</template>

<script lang="ts">
    import { defineComponent, getCurrentInstance } from "vue";
    import { EventBus } from "../../stores/event-bus";

    export default defineComponent({
        setup() {
            const app = getCurrentInstance();
            var eventBus = app?.appContext.config.globalProperties.$eventBus as EventBus;

            eventBus.on("hello-world", function () {
                console.log("hello-world-event")
            })

            setTimeout(() => {
                eventBus.emit("hello-world");
            }, 5000)

            console.log(eventBus)
        }
    })
</script>